import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerImageContainerComponent } from './customer-image-container.component';

describe('CustomerImageContainerComponent', () => {
  let component: CustomerImageContainerComponent;
  let fixture: ComponentFixture<CustomerImageContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerImageContainerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerImageContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
