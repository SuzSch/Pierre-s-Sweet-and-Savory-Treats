@{
  Layout = "_Layout";
}

<h1> Manage your account </h1>

@if (User.Identity.IsAuthenticated)
{
    <p>Hello @User.Identity.Name!</p>
    @using (Html.BeginForm("LogOff", "Account"))
    {
        < input type = "submit" value = "Log out" />
    }
}
