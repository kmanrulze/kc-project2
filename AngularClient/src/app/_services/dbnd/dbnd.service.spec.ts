import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { DbndService } from './dbnd.service';

describe('DbndService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule]
  }));

  it('should be created', () => {
    const service: DbndService = TestBed.get(DbndService);
    expect(service).toBeTruthy();
  });
});
