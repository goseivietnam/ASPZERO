import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrEditTaskModalComponentComponent } from './add-or-edit-task-modal-component.component';

describe('AddOrEditTaskModalComponentComponent', () => {
  let component: AddOrEditTaskModalComponentComponent;
  let fixture: ComponentFixture<AddOrEditTaskModalComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrEditTaskModalComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrEditTaskModalComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
