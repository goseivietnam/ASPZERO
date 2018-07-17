import { Component, OnInit, ViewChild, ElementRef, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import {  EmployeeServiceProxy, EmployeeDto, TaskServiceProxy, TaskListDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-assign-task',
  templateUrl: './assign-task.component.html',
  styleUrls: ['./assign-task.component.css']
})
export class AssignTaskComponent extends AppComponentBase {

    @ViewChild('assignTaskModal') assignTaskModal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    employees: EmployeeDto[] = [];
    selectedEmployee: EmployeeDto = null;
    selectedTask: TaskListDto = null;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;


    constructor(injector: Injector, private _employeeService: EmployeeServiceProxy, private _taskService: TaskServiceProxy) {
        super(injector);
    }

    getEmployees() {
        this._employeeService.getAll(0, 10).subscribe(result => { this.employees = result.items });
    }
    show(item: TaskListDto): void {
            this.getEmployees();
            this.active = true;
        this.assignTaskModal.show();
        this.selectedTask = item;
    }
    select(item: EmployeeDto): void {
        this.selectedEmployee = item;
        this.selectedTask.employeeId = item.id;
    }
    save(): void {
        this.saving = true;
        this._taskService.update(this.selectedTask)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('Assign Successfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }
    close(): void {
        this.active = false;
        this.assignTaskModal.hide();
    }
}
