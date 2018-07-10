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

    task1: TaskListDto = null;

    constructor(injector: Injector, private _taskService: TaskServiceProxy) {
        super(injector);
    }

    show(task: TaskListDto): void {
        this.selectedState = task.state;
        this.task1 = task;
        this.active = true;
        this.editTaskModal.show();
    }

    save(): void {
        
        this.task1.state = this.selectedState;
        this._taskService.update(this.task1)
            .finally(() => { this.saving = false; })
            .subscribe(result => {
                this.notify.info(this.l('Update Successfully!'));
                this.close();
                this.modalSave.emit(result);
            })
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }
    close(): void {
        this.active = false;
        this.editTaskModal.hide();
    }

}
