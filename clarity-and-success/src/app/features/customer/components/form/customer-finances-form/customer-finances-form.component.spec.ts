import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerFinancesFormComponent } from './customer-finances-form.component';

describe('CustomerFinancesFormComponent', () => {
  let component: CustomerFinancesFormComponent;
  let fixture: ComponentFixture<CustomerFinancesFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerFinancesFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerFinancesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
