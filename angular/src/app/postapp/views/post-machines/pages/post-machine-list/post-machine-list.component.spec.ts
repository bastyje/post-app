import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostMachineListComponent } from './post-machine-list.component';

describe('PostMachineListComponent', () => {
  let component: PostMachineListComponent;
  let fixture: ComponentFixture<PostMachineListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostMachineListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostMachineListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
