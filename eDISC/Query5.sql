SELECT d.*, b.Id as BrandsId, b.Name as BrandName, t.Id as TagsId, t.Name as TagsName FROM Discs d JOIN DiscTags dt on dt.DiscId=d.Id JOIN Tags t on t.Id=dt.TagId JOIN Brands b on b.Id=d.BrandId


<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Id)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Name)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.BrandId)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Condition)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Speed)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Glide)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Turn)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Fade)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Plastic)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Price)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Weight)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.ImageUrl)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Id)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Name)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Brand.Name)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Condition)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Speed)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Glide)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Turn)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Fade)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Plastic)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Price)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Weight)
            </td>
            <td>
                <img style="max-height: 7rem" src="https://discgolfoutlet.fi/tuotekuvat/1200x1200/Ch_Destroyer_600px.jpg" alt="disc" />
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
                @Html.ActionLink("Details", "Details", new { id=item.Id }) |
                @Html.ActionLink("Delete", "Delete", new { id=item.Id })
            </td>
        </tr>
}
    </tbody>
</table>




<dl class="row">
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Id)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Id)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Name)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Name)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.BrandId)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.BrandId)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Condition)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Condition)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Speed)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Speed)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Glide)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Glide)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Turn)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Turn)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Fade)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Fade)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Plastic)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Plastic)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Price)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Price)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.Weight)
        </dt>
        <dd class = "col-sm-10">
            @Html.DisplayFor(model => model.Weight)
        </dd>
        <dt class = "col-sm-2">
            @Html.DisplayNameFor(model => model.ImageUrl)
        </dt>
        <dd class = "col-sm-10">
            <img style="max-width: 8rem" class="bg-info" src="https://discgolfoutlet.fi/tuotekuvat/1200x1200/Ch_Destroyer_600px.jpg" alt="disc" />
        </dd>
    </dl>
</div>