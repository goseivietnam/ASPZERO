import { Component, OnInit, ViewChild, Injector, Output, ElementRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TaskServiceProxy, CreateTaskInput, TaskState } from '@shared/service-proxies/service-proxies';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-or-edit-task-modal',
  templateUrl: './add-or-edit-task-modal.component.html',
  styleUrls: ['./add-or-edit-task-modal.component.css']
})
export class AddOrEditTaskModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal') modal: ModalDirective
    @ViewChild('modalContent') modalContent: ElementRef;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;
    task: CreateTaskInput = new CreateTaskInput();

    //selectedState: TaskState;
    //stateSelectOptions = [
    //    { text: this.l('Open'), value: TaskState._0 },
    //    { text: this.l('Completed'), value: TaskState._1 }
    //];

    constructor(injector: Injector,private taskService: TaskServiceProxy) {
            super(injector);
        }

    show(): void {

        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }

    save(): void {
        this.saving = true;
        this.taskService.create(this.task)
            .finally(() => { this.saving = false; })
            .subscribe(result => {
                this.notify.info(this.l('Saved Successfully!'));
                this.close();
                this.modalSave.emit(this.task);
                //location.reload();
            }); 
    }
    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

}
