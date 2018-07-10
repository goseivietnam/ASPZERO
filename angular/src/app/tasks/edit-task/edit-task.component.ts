import { Component, OnInit, ViewChild, ElementRef, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { TaskServiceProxy, TaskListDto, TaskState, TaskListDtoState } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent extends AppComponentBase {

    @ViewChild('editTaskModal') editTaskModal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;
    selectedState: TaskListDtoState;
    stateSelectOptions = [
        { text: this.l('Open'), value: TaskListDtoState._0 },
        { text: this.l('Completed'), value: TaskListDtoState._1 }
    ]

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    task: TaskListDto = null;

    constructor(injector: Injector, private taskService: TaskServiceProxy) {
        super(injector);
    }

    show(task: TaskListDto): void {
        this.selectedState = task.state;
        this.task = task;
        this.active = true;
        this.editTaskModal.show();
    }

    save(): void {

    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }
    close(): void {
        this.active = false;
        this.editTaskModal.hide();
    }

}
