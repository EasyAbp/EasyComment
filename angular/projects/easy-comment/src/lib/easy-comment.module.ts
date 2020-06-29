import { NgModule } from '@angular/core';
import { EasyCommentComponent } from './components/easy-comment.component';
import { EasyCommentRoutingModule } from './easy-comment-routing.module';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CoreModule } from '@abp/ng.core';

@NgModule({
  declarations: [EasyCommentComponent],
  imports: [CoreModule, ThemeSharedModule, EasyCommentRoutingModule],
  exports: [EasyCommentComponent],
})
export class EasyCommentModule {}
