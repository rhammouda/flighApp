/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AirplanesComponent } from './Airplanes.component';

describe('AirplanesComponent', () => {
  let component: AirplanesComponent;
  let fixture: ComponentFixture<AirplanesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AirplanesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AirplanesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
