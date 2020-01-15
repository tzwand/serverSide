import { TestBed } from '@angular/core/testing';

import { AddLearningService } from './add-learning.service';

describe('AddLearningService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AddLearningService = TestBed.get(AddLearningService);
    expect(service).toBeTruthy();
  });
});
