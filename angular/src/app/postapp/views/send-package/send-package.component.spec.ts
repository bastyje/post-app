import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendPackageComponent } from './send-package.component';

describe('SendPackageComponent', () => {
  let component: SendPackageComponent;
  let fixture: ComponentFixture<SendPackageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendPackageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SendPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
