import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportantDragComponent } from './important-drag.component';

describe('ImportantDragComponent', () => {
  let component: ImportantDragComponent;
  let fixture: ComponentFixture<ImportantDragComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportantDragComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportantDragComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
