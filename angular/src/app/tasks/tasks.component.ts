import { Component, OnInit, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { TaskListDto, TaskState, TaskServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { AddOrEditTaskModalComponent } from '@app/tasks/add-or-edit-task-modal/add-or-edit-task-modal.component';
import { EditTaskComponent } from '@app/tasks/edit-task/edit-task.component';
@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent extends AppComponentBase implements OnInit {
    @ViewChild('addOrEditTaskModal') addOrEditTaskModal: AddOrEditTaskModalComponent;
    @ViewChild('editTaskModal') editTaskModal: EditTaskComponent;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    tasks: TaskListDto[] = [];
    selectedState: TaskState;
    stateSelectOptions = [
        { text: this.l('AllTasks'), value: undefined },
        { text: this.l('TaskState_Open'), value: TaskState._0 },
        { text: this.l('TaskState_Completed'), value: TaskState._1 }
    ]
    constructor(injector: Injector, private taskService: TaskServiceProxy) {
        super(injector);
    }

    ngOnInit() {
        this.getTasks();
    }

    getTasks() {
        this.taskService.getAll(this.selectedState as any).subscribe(result => { this.tasks = result.items });
    }

    getTaskLable(task: TaskListDto) {
        return task.state === TaskState1.Open ? 'lable-success' : 'lable-default';
    }

    getTaskState(task: TaskListDto) {
        switch (task.state) {
            case TaskState1.Open:
                return this.l('Open');
            case TaskState1.Completed:
                return this.l('Completed');
            default:
                return '';
        }
    }
    ShowTaskModal() {
        this.addOrEditTaskModal.show();
    }
    OnTaskUpdate(task: TaskListDto) {
        this.tasks.push(task);
        this.notify.success(this.l('SavedSuccessully'));
    }

    editTask(task: TaskListDto): void {
        this.editTaskModal.show(task);
    }
    protected delete(id: number): void {
        abp.message.confirm(
            "You want to delete this Task?",
            (result: boolean) => {
                if (result) {
                    this.taskService.delete(id)
                        .subscribe(() => {
                            abp.notify.info("Deleted Success!");
                            this.modalSave.emit(this.tasks);
                            location.reload();
                        });
                }
            }
        );
    }
}
export class TaskState1 {
    static Open: number = 0;
    static Completed: number = 1;
}
