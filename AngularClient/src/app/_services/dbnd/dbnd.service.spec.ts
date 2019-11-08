import { TestBed } from '@angular/core/testing';

import { DbndService } from './dbnd.service';

describe('DbndService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DbndService = TestBed.get(DbndService);
    expect(service).toBeTruthy();
  });
});
