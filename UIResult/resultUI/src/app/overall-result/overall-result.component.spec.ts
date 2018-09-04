import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OverallResultComponent } from './overall-result.component';

describe('OverallResultComponent', () => {
  let component: OverallResultComponent;
  let fixture: ComponentFixture<OverallResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OverallResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OverallResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
