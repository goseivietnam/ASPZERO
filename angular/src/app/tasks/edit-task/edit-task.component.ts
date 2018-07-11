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

    show(id: number): void {
        this._taskService.getAsync(id).subscribe((result) => {
            this.selectedState = result.state;
            this.task1 = result;
            this.active = true;
            this.editTaskModal.show();
        });
    }

    save(): void {
        
        this.task1.state = this.selectedState;
        this._taskService.update(this.task1)
            .finally(() => { this.saving = false; })
            .subscribe(result => {
                this.notify.info(this.l('Update Successfully!'));
                this.close();
                this.modalSave.emit(null);
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
