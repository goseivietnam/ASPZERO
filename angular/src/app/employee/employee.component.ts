import { Component, Injector, ViewChild } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { EmployeeDto, EmployeeServiceProxy, PagedResultDtoOfEmployeeDto, EmployeeDto1 } from '@shared/service-proxies/service-proxies';
import { CreateEmployeeComponent } from '@app/employee/create-employee/create-employee.component';
import { EditEmployeeComponent } from '@app/employee/edit-employee/edit-employee.component';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent extends PagedListingComponentBase <EmployeeDto> {

    @ViewChild('editEmployeeModal') editEmployeeModal: EditEmployeeComponent;
    @ViewChild('createEmployeeModal') createEmployeeModal: CreateEmployeeComponent;

    active: boolean = false;
    employees: EmployeeDto[] = [];
    employees1: EmployeeDto1[] = [];
    currenttime = Date.now();

    constructor(injector: Injector, private _employeeService: EmployeeServiceProxy) {
        super(injector);
    }


    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._employeeService.getAll2()
            .finally(() => {
                finishedCallback();
            })
            .subscribe((result) => {
                if (this.pageNumber * this.pageSize < result.length) {
                    this.employees1 = result.slice(request.skipCount, request.skipCount + this.pageSize);
                }
                else {
                    this.employees1 = result.slice(request.skipCount, result.length);
                }
                this.showPaging1(result, pageNumber);
            });
    }

    protected delete(entity: EmployeeDto): void {
        abp.message.confirm(
            "Delete employee '" + entity.name + "'?",
            (result: boolean) => {
                if (result) {
                    this._employeeService.delete(entity.id).subscribe(() => {
                        abp.notify.info("Deleted Employee: " + entity.name);
                        this.refresh();
                    });
                }
            }
        );
    }

    deletemulti() {
        abp.message.confirm(
            "Delete employees checked!",
            (result: boolean) => {
                if (result) {
                    for (let item of this.employees) {
                        if ($("#" + item.id)[0].checked) {
                            this._employeeService.delete(item.id).subscribe(() => {
                                abp.notify.info("Deleted Employee: " + item.name);

                            });
                        }
                    }
                    this.refresh();
                };
                }
        );
    }
    //Show Modals

    edit(employee: EmployeeDto) {
        this.editEmployeeModal.show(employee.id);
    }

    create() {
        this.createEmployeeModal.show();
    }
    a: number = 0;
    selectbox() {
        if (this.a == 0) {
            for (let item of this.employees) {
                $("#" + item.id)[0].checked = true;
            }
        }
        if (this.a == 1) {

            for (let item of this.employees) {
                $("#" + item.id)[0].checked = false;
            }
        }
        this.a = (this.a == 0 ? 1 : 0);
    
    }
}
