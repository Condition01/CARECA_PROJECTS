import { TestBed } from '@angular/core/testing';

import { CarecaService } from './careca.service';

describe('CarecaService', () => {
  let service: CarecaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarecaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
