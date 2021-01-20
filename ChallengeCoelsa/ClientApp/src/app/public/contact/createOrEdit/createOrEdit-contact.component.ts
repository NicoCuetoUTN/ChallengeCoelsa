import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from 'src/app/infraestructure/model/interfaces/contact.interface';
import { ContactService } from 'src/app/infraestructure/services/contact.service';

@Component({
  selector: 'createOrEdit-Contacts',
  templateUrl: './createOrEdit-Contact.component.html'
})
export class CreateOrEditContactComponent implements OnInit {
  model: Contact = <Contact>{};
  errors: [] = [];
  isNew: boolean = false;

  constructor(private contactService: ContactService,
    private aRoute: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.aRoute.params.subscribe((params) => {
      this.model.id = params['contactId'];
      if (this.model.id)
        this.contactService.getById(this.model.id).subscribe((data: Contact) => {
          this.model = data;
        });
      else {
        this.isNew = true;
        this.contactService.getAll();
      }
    });
  }

  submit() {
    if (this.validateModel()) {
      this.contactService.post(this.model).subscribe(response => {
        response && this.isNew ? this.router.navigate(['../'], { relativeTo: this.aRoute })
          : this.router.navigate(['../../'], { relativeTo: this.aRoute })

      });
    }
  }

  validateModel() {
    this.errors = [];
    //We can return error key of an static translator LANG asset
    if (!this.model.firstName) {
      this.errors['firstName'] = 'This field is required';
    }
    if (!this.model.lastName) {
      this.errors['lastName'] = 'This field is required';
    }
    if (!this.model.company) {
      this.errors['company'] = 'This field is required';
    }
    if (!this.model.phoneNumber) {
      this.errors['phoneNumber'] = 'This field is required';
    }
    else if (!this.validatePhone(this.model.phoneNumber)) {
      this.errors['phoneNumber'] = 'You have entered an invalid Phone Number';
    }
    if (!this.model.email) {
      this.errors['email'] = 'This field is required';
    }
    else if (!this.validateEmail(this.model.email)) {
      this.errors['email'] = 'You have entered an invalid email address!';
    }
    else
      return true;
  }

  validateEmail(email) {
    const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return regularExpression.test(String(email).toLowerCase());
  }

  validatePhone(phone: string) {
    const regularExpression = /\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/
    return regularExpression.test(phone)
  }

}


