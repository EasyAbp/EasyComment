import { Injectable } from '@angular/core';
import { eLayoutType, addAbpRoutes, ABP } from '@abp/ng.core';
import { addSettingTab } from '@abp/ng.theme.shared';
import { EasyCommentSettingsComponent } from '../components/easy-comment-settings.component';

@Injectable({
  providedIn: 'root',
})
export class EasyCommentConfigService {
  constructor() {
    addAbpRoutes({
      name: 'EasyComment',
      path: 'easy-comment',
      layout: eLayoutType.application,
      order: 2,
    } as ABP.FullRoute);

    const route = addSettingTab({
      component: EasyCommentSettingsComponent,
      name: 'EasyComment Settings',
      order: 1,
      requiredPolicy: '',
    });
  }
}
