import { TestBed } from '@angular/core/testing';
import { ArchivedTasksService } from './archived-tasks.service';

describe('ArchivedTasksService', () => {
  let service: ArchivedTasksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ArchivedTasksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
