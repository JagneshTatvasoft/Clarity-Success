import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerFurtherData2FormComponent } from './customer-further-data2-form.component';

describe('CustomerFurtherData2FormComponent', () => {
  let component: CustomerFurtherData2FormComponent;
  let fixture: ComponentFixture<CustomerFurtherData2FormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerFurtherData2FormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerFurtherData2FormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
