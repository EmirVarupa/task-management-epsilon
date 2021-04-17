import { TestBed } from '@angular/core/testing';

import { ImportantTasksService } from './important-tasks.service';

describe('ImportantTasksService', () => {
  let service: ImportantTasksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImportantTasksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
