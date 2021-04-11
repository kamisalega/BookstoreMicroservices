import { TestBed } from '@angular/core/testing';

import { BasketWrapperService } from './basket.wrapper.service';

describe('BasketWrapperService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BasketWrapperService = TestBed.get(BasketWrapperService);
    expect(service).toBeTruthy();
  });
});
