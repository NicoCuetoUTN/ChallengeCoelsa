import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from 'src/app/infraestructure/model/interfaces/contact.interface';
import { ContactService } from 'src/app/infraestructure/services/contact.service';

@Component({
  selector: 'Contact-list',
  templateUrl: './Contact-list.component.html'
})
export class ContactListComponent implements OnInit {
  public contacts: Contact[];

  constructor(private contactService: ContactService,
    private router: Router,
    private aRoute: ActivatedRoute) { }

  ngOnInit() {
    this.contactService.get()
      .subscribe((data: any) => {
        this.contacts = data.value;
      });
  }

  goToCreateOrEdit(id?: string) {
    id ? this.router.navigate(['edit', id], { relativeTo: this.aRoute })
       : this.router.navigate(['create'], { relativeTo: this.aRoute })
  }

  deleteContact(modelId: string){
    this.contactService.delete(modelId).subscribe(data => data);

  }
}


