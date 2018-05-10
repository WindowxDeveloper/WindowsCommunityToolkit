// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Graph;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Graph
{
    /// <summary>
    /// Defines the properties for the <see cref="PeoplePicker"/> control.
    /// </summary>
    public partial class PeoplePicker : Control
    {
        /// <summary>
        /// Gets required delegated permissions for the <see cref="PeoplePicker"/> control
        /// </summary>
        public static string[] RequiredDelegatedPermissions
        {
            get
            {
                return new string[] { "User.Read", "User.ReadBasic.All" };
            }
        }

        /// <summary>
        /// Identifies the <see cref="AllowMultiple"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty AllowMultipleProperty =
            DependencyProperty.Register(
                nameof(AllowMultiple),
                typeof(bool),
                typeof(PeoplePicker),
                new PropertyMetadata(true, AllowMultiplePropertyChanged));

        /// <summary>
        /// Identifies the <see cref="SearchResultLimit"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchResultLimitProperty =
            DependencyProperty.Register(
                nameof(SearchResultLimit),
                typeof(int),
                typeof(PeoplePicker),
                null);

        /// <summary>
        /// Identifies the <see cref="PlaceholderText"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register(
                nameof(PlaceholderText),
                typeof(string),
                typeof(PeoplePicker),
                new PropertyMetadata("Enter keywords to search people"));

        /// <summary>
        /// Identifies the <see cref="Selections"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectionsProperty =
            DependencyProperty.Register(
                nameof(Selections),
                typeof(ObservableCollection<Person>),
                typeof(PeoplePicker),
                null);

        /// <summary>
        /// Identifies the <see cref="SearchResultList"/> dependency property.
        /// </summary>
        internal static readonly DependencyProperty SearchResultListProperty =
            DependencyProperty.Register(
                nameof(SearchResultList),
                typeof(ObservableCollection<Person>),
                typeof(PeoplePicker),
                null);

        /// <summary>
        /// Gets or sets a value indicating whether multiple people can be selected
        /// </summary>
        public bool AllowMultiple
        {
            get => (bool)GetValue(AllowMultipleProperty);
            set => SetValue(AllowMultipleProperty, value);
        }

        /// <summary>
        /// Gets or sets the max person returned in the search results
        /// </summary>
        public int SearchResultLimit
        {
            get => (int)GetValue(SearchResultLimitProperty);
            set => SetValue(SearchResultLimitProperty, value);
        }

        /// <summary>
        /// Gets or sets the text to be displayed when no user is selected
        /// </summary>
        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the selected person list.
        /// </summary>
        public ObservableCollection<Person> Selections
        {
            get => (ObservableCollection<Person>)GetValue(SelectionsProperty);
            set => SetValue(SelectionsProperty, value);
        }

        internal ObservableCollection<Person> SearchResultList
        {
            get => (ObservableCollection<Person>)GetValue(SearchResultListProperty);
            set => SetValue(SearchResultListProperty, value);
        }

        private ICommand _deleteItemCommand;

        /// <summary>
        /// Gets the command to delete the selected item.
        /// </summary>
        public ICommand DeleteItemCommand
        {
            get
            {
                if (_deleteItemCommand == null)
                {
                    _deleteItemCommand = new DelegateCommand(DeleteSelectedItem);
                }

                return _deleteItemCommand;
            }
        }
    }
}