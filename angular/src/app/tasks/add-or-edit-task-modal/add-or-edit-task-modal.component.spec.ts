import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrEditTaskModalComponent } from './add-or-edit-task-modal.component';

describe('AddOrEditTaskModalComponent', () => {
  let component: AddOrEditTaskModalComponent;
  let fixture: ComponentFixture<AddOrEditTaskModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrEditTaskModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrEditTaskModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
