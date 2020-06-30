﻿using System;
using System.Threading.Tasks;
using EasyAbp.EasyComment.Comments;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Widgets;

namespace EasyAbp.EasyComment.Web.Pages.Shared.Components.CommentViewerWidget
{
    [Widget(
        RefreshUrl = "/widgets/easyComment/showCommentViewer"
    )]
    public class CommentViewerWidgetViewComponent : AbpViewComponent
    {
        private readonly ICommentAppService _service;

        public CommentViewerWidgetViewComponent(ICommentAppService service)
        {
            _service = service;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(Guid id, string content, bool refreshData)
        {
            if (refreshData)
            {
                var comment = await _service.GetAsync(id);
                content = comment.Content;
            }
            return View(new CommentViewerViewModel
            {
                Id = id,
                Content = content,
            });
        } 
    }
}