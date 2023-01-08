import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostMachineDetailComponent } from './post-machine-detail.component';

describe('PostMachineDetailComponent', () => {
  let component: PostMachineDetailComponent;
  let fixture: ComponentFixture<PostMachineDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostMachineDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostMachineDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
