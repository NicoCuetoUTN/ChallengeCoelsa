import { Component, OnInit } from '@angular/core';
import { Contact } from 'src/app/infraestructure/model/interfaces/contact.interface';
import { ContactService } from 'src/app/infraestructure/services/contact.service';

@Component({
  selector: 'createOrEdit-Contacts',
  templateUrl: './createOrEdit-Contact.component.html'
})
export class CreateOrEditContactComponent implements OnInit {
  model: Contact = <Contact>{};
  errors: [];

  constructor( private contactService: ContactService) {}

  ngOnInit(){
  }

  submit(){
    if(this.validateModel()){
      this.contactService.post(this.model).subscribe(response =>{
        console.log(response);
      })
    }
  }

  validateModel(){
      this.errors = [];
    //We can return error key of an static translator LANG asset
      if(!this.model.firstName){
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
      if (!this.model.email) {
        this.errors['email'] = 'This field is required';
      }
      else
        return true;
      
     
    }
  
}


