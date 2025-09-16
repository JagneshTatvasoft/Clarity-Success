import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerBasicInfoFormComponent } from './customer-basic-info-form.component';

describe('CustomerBasicInfoFormComponent', () => {
  let component: CustomerBasicInfoFormComponent;
  let fixture: ComponentFixture<CustomerBasicInfoFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerBasicInfoFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerBasicInfoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
