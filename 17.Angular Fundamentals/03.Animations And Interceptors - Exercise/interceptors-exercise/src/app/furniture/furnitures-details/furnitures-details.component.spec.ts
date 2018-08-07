import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FurnituresDetailsComponent } from './furnitures-details.component';

describe('FurnituresDetailsComponent', () => {
  let component: FurnituresDetailsComponent;
  let fixture: ComponentFixture<FurnituresDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FurnituresDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FurnituresDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
