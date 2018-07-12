import { Component, OnInit, Output, ViewChild, EventEmitter, ElementRef, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { EmployeeServiceProxy, CreateEmployeeDto } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-create-employee',
  templateUrl: './create-employee.component.html',
  styleUrls: ['./create-employee.component.css']
})
export class CreateEmployeeComponent extends AppComponentBase implements OnInit {
    @ViewChild('createEmployeeModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    employee: CreateEmployeeDto = null;
    date;

    active: boolean = false;
    saving: boolean = false;

    constructor(injector: Injector, private _employeeService: EmployeeServiceProxy) {
        super(injector);
    }

    show() {
        this.active = true;
        this.modal.show();
        this.employee = new CreateEmployeeDto();
    }
    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }
    save() {
        this.saving = true;
        this.employee.birthday = moment(this.date).add(7, 'hours');
        this._employeeService.create(this.employee)
            .finally(() => { this.saving = false; })
            .subscribe(result => {
                this.notify.info(this.l('Saved Successfully!'));
                this.close();
                this.modalSave.emit(null);
            });
    }
    close() {
        this.active = false;
        this.modal.hide();
    }

    ngOnInit() {
        this.date = moment(Date.now()).format('YYYY-MM-DD');
  }

}
