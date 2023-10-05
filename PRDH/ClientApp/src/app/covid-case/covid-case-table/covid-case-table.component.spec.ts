import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CovidCaseTableComponent } from './covid-case-table.component';

describe('CovidCaseTableComponent', () => {
  let component: CovidCaseTableComponent;
  let fixture: ComponentFixture<CovidCaseTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CovidCaseTableComponent]
    });
    fixture = TestBed.createComponent(CovidCaseTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
