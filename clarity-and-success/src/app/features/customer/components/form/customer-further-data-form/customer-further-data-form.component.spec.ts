import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerFurtherDataFormComponent } from './customer-further-data-form.component';

describe('CustomerFurtherDataFormComponent', () => {
  let component: CustomerFurtherDataFormComponent;
  let fixture: ComponentFixture<CustomerFurtherDataFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerFurtherDataFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerFurtherDataFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
