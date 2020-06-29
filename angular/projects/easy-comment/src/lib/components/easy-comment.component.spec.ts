import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EasyCommentComponent } from './easy-comment.component';

describe('EasyCommentComponent', () => {
  let component: EasyCommentComponent;
  let fixture: ComponentFixture<EasyCommentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EasyCommentComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EasyCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
