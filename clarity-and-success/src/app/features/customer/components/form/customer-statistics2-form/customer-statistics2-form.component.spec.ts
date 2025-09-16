import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerStatistics2FormComponent } from './customer-statistics2-form.component';

describe('CustomerStatistics2FormComponent', () => {
  let component: CustomerStatistics2FormComponent;
  let fixture: ComponentFixture<CustomerStatistics2FormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerStatistics2FormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerStatistics2FormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
