import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemarkFormComponent } from './remark-form.component';

describe('RemarkFormComponent', () => {
  let component: RemarkFormComponent;
  let fixture: ComponentFixture<RemarkFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemarkFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemarkFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
