﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using InDrivoHRM.Models.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using InDrivoHRM.Models;

namespace InDrivoHRM.Pages
{
    public partial class AddTaskComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected CrmService Crm { get; set; }

        IEnumerable<InDrivoHRM.Models.Crm.Opportunity> _getOpportunitiesResult;
        protected IEnumerable<InDrivoHRM.Models.Crm.Opportunity> getOpportunitiesResult
        {
            get
            {
                return _getOpportunitiesResult;
            }
            set
            {
                if (!object.Equals(_getOpportunitiesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getOpportunitiesResult", NewValue = value, OldValue = _getOpportunitiesResult };
                    _getOpportunitiesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<InDrivoHRM.Models.Crm.TaskType> _getTaskTypesResult;
        protected IEnumerable<InDrivoHRM.Models.Crm.TaskType> getTaskTypesResult
        {
            get
            {
                return _getTaskTypesResult;
            }
            set
            {
                if (!object.Equals(_getTaskTypesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTaskTypesResult", NewValue = value, OldValue = _getTaskTypesResult };
                    _getTaskTypesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<InDrivoHRM.Models.Crm.TaskStatus> _getTaskStatusesResult;
        protected IEnumerable<InDrivoHRM.Models.Crm.TaskStatus> getTaskStatusesResult
        {
            get
            {
                return _getTaskStatusesResult;
            }
            set
            {
                if (!object.Equals(_getTaskStatusesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getTaskStatusesResult", NewValue = value, OldValue = _getTaskStatusesResult };
                    _getTaskStatusesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        InDrivoHRM.Models.Crm.Task _task;
        protected InDrivoHRM.Models.Crm.Task task
        {
            get
            {
                return _task;
            }
            set
            {
                if (!object.Equals(_task, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "task", NewValue = value, OldValue = _task };
                    _task = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var crmGetOpportunitiesResult = await Crm.GetOpportunities();
            getOpportunitiesResult = crmGetOpportunitiesResult;

            var crmGetTaskTypesResult = await Crm.GetTaskTypes();
            getTaskTypesResult = crmGetTaskTypesResult;

            var crmGetTaskStatusesResult = await Crm.GetTaskStatuses();
            getTaskStatusesResult = crmGetTaskStatusesResult;

            task = new InDrivoHRM.Models.Crm.Task(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(InDrivoHRM.Models.Crm.Task args)
        {
            try
            {
                var crmCreateTaskResult = await Crm.CreateTask(task);
                DialogService.Close(task);
            }
            catch (System.Exception crmCreateTaskException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Task!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
