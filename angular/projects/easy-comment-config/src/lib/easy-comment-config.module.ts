import { NgModule, APP_INITIALIZER } from '@angular/core';
import { EasyCommentConfigService } from './services/easy-comment-config.service';
import { noop } from '@abp/ng.core';
import { EasyCommentSettingsComponent } from './components/easy-comment-settings.component';

@NgModule({
  declarations: [EasyCommentSettingsComponent],
  providers: [{ provide: APP_INITIALIZER, deps: [EasyCommentConfigService], multi: true, useFactory: noop }],
  exports: [EasyCommentSettingsComponent],
  entryComponents: [EasyCommentSettingsComponent],
})
export class EasyCommentConfigModule {}
