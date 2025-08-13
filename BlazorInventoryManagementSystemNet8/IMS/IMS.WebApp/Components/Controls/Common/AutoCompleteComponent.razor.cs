using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace IMS.WebApp.Components.Controls.Common
{
    public partial class AutoCompleteComponent
    {
        #region Fields
        private string _userInput = string.Empty;
        private List<ItemViewModel>? _searchResults = null;
        private ItemViewModel? _selectedItem = null;
        private ItemViewModel? _currentItem = null;
        private int _currentItemIndex = -1;
        #endregion

        #region Properties
        [Parameter]
        public string Label { get; set; } = string.Empty;

        [Parameter]
        public Func<string, Task<List<ItemViewModel>>>? SearchFunction { get; set; }

        [Parameter]
        public EventCallback<ItemViewModel> OnItemSelected { get; set; }

        public string UserInput 
        { 
            get => _userInput;
            set 
            {
                _userInput = value;
                if(!string.IsNullOrWhiteSpace(_userInput) && SearchFunction != null)
                {
                    ViewItemsAsync();
                }
            }
        }
        #endregion

        #region Methods

        private async Task ViewItemsAsync()
        {
            if(SearchFunction != null)
            {
                _searchResults = await SearchFunction(_userInput);
                StateHasChanged();
            }
        }

        private void HandleSelectItem(ItemViewModel? item)
        {
            ClearHighlighting();
            if(item is not null)
            {
                _selectedItem = item;
                _userInput = item?.Name ?? string.Empty;
                _searchResults = null;
                OnItemSelected.InvokeAsync(item);
            }

        }

        private void ClearHighlighting()
        {
            _searchResults = null;
            _currentItem = null;
            _currentItemIndex = -1;
        }

        private void OnKeyUp(KeyboardEventArgs e)
        {
            if(_searchResults is not null && _searchResults.Count > 0 && (e.Code == "ArrowDown" || e.Code == "ArrowUp"))
            {
                if(e.Code == "ArrowDown" && _currentItemIndex < _searchResults.Count - 1)
                {
                    _currentItem = _searchResults[++_currentItemIndex];
                }
                else if (e.Code == "ArrowUp")
                {
                    if(_currentItemIndex > 0)
                        _currentItem = _searchResults[--_currentItemIndex];
                    else
                    {
                        _currentItem = null;
                        _currentItemIndex = -1;
                    }
                }
            }
            else if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                HandleSelectItem(_currentItem);
            }
        }
        #endregion
    }

    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}