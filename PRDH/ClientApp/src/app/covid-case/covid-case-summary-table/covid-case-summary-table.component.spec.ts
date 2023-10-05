import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CovidCaseSummaryTableComponent } from './covid-case-summary-table.component';

describe('CovidCaseSummaryTableComponent', () => {
  let component: CovidCaseSummaryTableComponent;
  let fixture: ComponentFixture<CovidCaseSummaryTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CovidCaseSummaryTableComponent]
    });
    fixture = TestBed.createComponent(CovidCaseSummaryTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
