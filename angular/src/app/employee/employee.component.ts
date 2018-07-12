import { Component, Injector, ViewChild } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { EmployeeDto, EmployeeServiceProxy, PagedResultDtoOfEmployeeDto } from '@shared/service-proxies/service-proxies';
import { CreateEmployeeComponent } from '@app/employee/create-employee/create-employee.component';
import { EditEmployeeComponent } from '@app/employee/edit-employee/edit-employee.component';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent extends PagedListingComponentBase <EmployeeDto> {

    @ViewChild('editEmployeeModal') editEmployeeModal: EditEmployeeComponent;

    active: boolean = false;
    employees: EmployeeDto[] = [];


    constructor(injector: Injector, private _employeeService: EmployeeServiceProxy) {
        super(injector);
    }


    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._employeeService.getAll(request.skipCount, request.maxResultCount)
            .finally(() => {
                finishedCallback();
            })
            .subscribe((result: PagedResultDtoOfEmployeeDto) => {
                this.employees = result.items;
                this.showPaging(result, pageNumber);
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

    //Show Modals

    edit(employee: EmployeeDto) {
        this.editEmployeeModal.show(employee.id);
    }

}
