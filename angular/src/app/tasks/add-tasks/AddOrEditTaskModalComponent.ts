import { Component, ViewChild, Output, EventEmitter, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { TaskServiceProxy, TaskListDto, CreateTaskInput } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'addOrEditTaskModal',
})

export class AddOrEditTaskModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    active = false;
    saving = false;
    task: CreateTaskInput = new CreateTaskInput()

    constructor(injector: Injector, private taskService: TaskServiceProxy) {
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
            .subscribe(result => { this.modalSave.emit(result); this.close(); });
    }
}
