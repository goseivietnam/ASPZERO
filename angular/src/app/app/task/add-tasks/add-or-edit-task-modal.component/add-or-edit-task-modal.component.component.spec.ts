import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrEditTaskModal.ComponentComponent } from './add-or-edit-task-modal.component.component';

describe('AddOrEditTaskModal.ComponentComponent', () => {
  let component: AddOrEditTaskModal.ComponentComponent;
  let fixture: ComponentFixture<AddOrEditTaskModal.ComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrEditTaskModal.ComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrEditTaskModal.ComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
