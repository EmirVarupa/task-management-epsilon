import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AssignedDragComponent } from './assigned-drag.component';

describe('AssignedDragComponent', () => {
  let component: AssignedDragComponent;
  let fixture: ComponentFixture<AssignedDragComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignedDragComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignedDragComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
