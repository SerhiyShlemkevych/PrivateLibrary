   M S B A M L   `   `   `  ����R  NEpamTask.PrivateLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:EpamTask.PrivateLibrary.InputValidation'EpamTask.PrivateLibrary.InputValidation  5   	   (    "EpamTask.PrivateLibrary.SignUpForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   QinputValidation5clr-namespace:EpamTask.PrivateLibrary.InputValidation     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$% Members: Sign up for membership��5	   	   $��421.34��61   $��827.812��6A    � 	Resources 5
         ValidationErrorTemplate �� ElementName �� Path ��Name��%  &	        �� 5   
   .R�5      ]� .+�5      �� $	��Top=�6   
���  ��$��11(�5   *   ��5      �� $ ErrorAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      $ ErrorAdorner��6-   5      5      5      .��5      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��366��6T   $��	10,10,0,0q�6a   $	��Top=�6t   $	��279��6�   ._�5      � -   5         �Name$ 
gridSignUp��5      $y�Visible=�6'   $��-1q�6<   .+�5      �� -   5         ��Name$ txtMemberFirstName��5      $
��Left=�6A   $��25��6`   $��
119,21,0,0q�6l    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��150��6�   	 =� ErrorTemplate#	 [  5      .��6^   .��5      �� $ 	FirstName�6   
 �� Mode$
 TwoWay=�6/    �� UpdateSourceTrigger$ PropertyChanged=�6=    �� ValidationRules 5      =   7EpamTask.PrivateLibrary.InputValidation.StringValidator  5      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6>   5      5       �� 5!      -   5        $ txtMemberLastName��5!      $
��Left=�6A   $��25��6`   $��
119,61,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   #	 [  5"      .��6^   .��5#      �� $ LastName�6   $
 TwoWay=�6.   $ PropertyChanged=�6<    5$        5%       . 6>   5'      5(      �� 5)      -   5        $ txtMemberEmail��5)      $
��Left=�6A   $��25��6`   $��119,100,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   #	 [  5*      .��6^   .��5+      �� $ Email�6   $
 TwoWay=�6+   $ PropertyChanged=�69    5,      <   6EpamTask.PrivateLibrary.InputValidation.EmailValidator  5-       . 6=   5/      50      �� 51      -   5        $ txtMemberPhoneNumber��51      $
��Left=�6A   $��25��6`   $��119,140,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   #	 [  52      .��6^   .��53      �� $ PhoneNumber�6   $
 TwoWay=�61   $ PropertyChanged=�6?    54      <   6EpamTask.PrivateLibrary.InputValidation.PhoneValidator  55       . 6=   57      58      �� 59      -   5        $ txtMemberCity��59      $
��Left=�6A   $��25��6`   $��119,180,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��150��6�   #	 [  5:      .��6^   .��5;      �� $
 City�6   $
 TwoWay=�6*   $ PropertyChanged=�68    5<        5=       . 6>   5?      5@      �� 5A      -   5         ��Name$ comboBoxMemberGender��5A      $
��Left=�6A   $��25��6`   $��119,221,0,0q�6l    �� SelectedIndex$ 0��6�   $	��Top=�6�   $	��150��6�    �� Text 6�   �� $ Gender�6�   �� 5B      -   5        $ comboBoxMembershipName��5B      $
��Left=�6A   $��25��6`   $��119,261,0,0q�6l   $ 0��6�   $	��Top=�6�   $	��150��6�    6�   �� $ MembershipName�6�   �� 5C      -	   5         ��Name$ lblMemberFirstName��5C      $��
First Name��69   $
��Left=�6Y   $	��Top=�6t   $��	10,20,0,0q�6�    J� RenderTransformOrigin$ 0.776,0.538&�6�   �� 5D      -
   5        $ lblMemberLastName��5D      $��	Last Name��69   $
��Left=�6Y   $	��Top=�6t   $��	10,60,0,0q�6�   �� 5E      -   5        $ lblMemberEmail��5E      $��Email��69   $
��Left=�6Y   $	��Top=�6t   $��
10,100,0,0q�6�   �� 5F      -   5        $ lblMemberPhoneNumber��5F      $��Phone Number��69   $
��Left=�6Y   $	��Top=�6t   $��
10,140,0,0q�6�   �� 5G      -   5        $ lblMemberGender��5G      $��Gender��69   $
��Left=�6Y   $	��Top=�6t   $��
10,220,0,0q�6�   �� 5H      -   5        $ lblMemberCity��5H      $
��City��69   $
��Left=�6Y   $	��Top=�6t   $��
10,180,0,0q�6�   �� 5I      -   5        $ lblMemberShipName��5I      $��Subscription Type��69   $
��Left=�6Y   $	��Top=�6t   $��
10,260,0,0q�6�   �� 5J      -   5         ��Name$ 	btnSubmit��5J      $��Submit��6,   $
��Left=�6=   $��191,332,0,0q�6X   $	��Top=�6m   $��78��6�   $��24��6�   6�   �� 5K      -   5        $ 	btnCancel��5K      $��Cancel��6,   $
��Left=�6=   $��
10,332,0,0q�6X   $	��Top=�6l   $��78��6�   $��24��6�   6�   5L      5M      �� 5N   
   
���   �$��1q�6%   $
��Left=�69   $	��365��6T   $��
294,10,0,0q�6a   $	��Top=�6u   $	��512��6�   ._�5O      � -   5        $��gridMembershipDetails��5O   %   $��0,0,0,-1q�6    � RowDefinitions 5P      �� 5Q      $��70 �6$   �� 5R      $��40 �6$   �� 5S      $��40 �6$   �� 5T      $��40 �6$   �� 5U      $��40 �6$   �� 5V      $��40 �6$   �� 5W      $��40 �6$   �� 5X      $��35 �6$    � ColumnDefinitions 5Z      �� 5[      $	��130 �6'   �� 5\      $	��120 �6'   �� 5]      $	��120 �6'   �� 5^      $	��120 �6'   .+�5`      �� $��1��6   $��0��6%   $��Book limit:��65   $��Right=�6U   $��Right=�6x   $��Center=�6�   $��28��6�   $	��126��6�   �� 5a      $��2��6   $��0��6%   $��Subscription duration:��65   $��Right=�6V   $��Right=�6y   $��Center=�6�   $��28��6�   $	��126��6�   �� 5b      $��3��6   $��0��6%   $��Price per month:��65   $��Right=�6U   $��Right=�6x   $��Center=�6�   $��28��6�   $	��126��6�   �� 5c      $��4��6   $��0��6%   $��Total price:��65   $��Right=�6U   $��Right=�6x   $��Center=�6�   $��28��6�   $	��126��6�   �� 5d      $��5��6   $��0��6%   $��Overdue day limit:��65   $��Right=�6U   $��Right=�6x   $��Center=�6�   $��28��6�   $	��126��6�   �� 5e      $��6��6   $��0��6%   $��Overdue fee:��65   $��Right=�6U   $��Right=�6x   $��Center=�6�   $��28��6�   $	��126��6�   5f      5g      5i      5j      