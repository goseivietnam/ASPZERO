import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter, Injector } from '@angular/core';
import { EmployeeServiceProxy, EmployeeDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';

import * as moment from 'moment';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent extends AppComponentBase {
    @ViewChild('editEmployeeModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    test1;
    employee: EmployeeDto = null;

    constructor(
        injector: Injector,
        private _employeeService: EmployeeServiceProxy
    ) {
        super(injector);
    }

    show(id: number): void {

        this._employeeService.get(id)
            .subscribe(
                (result) => {
                    this.employee = result;
                    this.test1 = this.employee.birthday.format('YYYY-MM-DD');
                    this.active = true;
                    this.modal.show();
                }
            );

    }
    save(): void {
        this.saving = true;
        this.employee.birthday = moment(this.test1).add(7, 'hours');
        this._employeeService.update(this.employee) 
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
