<template>
  <div class="container">
    	<div class="row">
			<div class="col-md-6">
				<div class="panel panel-primary">
					<div class="panel-heading">
						<h3 class="panel-title">Applicant</h3>
						<div class="pull-right">
							<span class="clickable filter" data-toggle="tooltip" title="Toggle table filter" data-container="body">
								<i class="glyphicon glyphicon-filter"></i>
							</span>
						</div>
					</div>
					<div class="panel-body">
						<input type="text" class="form-control" id="dev-table-filter" data-action="filter" data-filters="#dev-table" placeholder="Filter Developers" />
					</div>
					<table class="table table-hover" id="dev-table">
						<thead>
							<tr>
								<th>Id</th>
								<th>Name</th>
								<th>Email</th>
								<th>Phone</th>
                <th>Matches</th>
                <th>Language</th>
                <th>School</th>
							</tr>
						</thead>
						<tbody>
							<tr>
								<td>1</td>
								<td>Kilgore</td>
								<td>Trout</td>
								<td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
							</tr>
              <tr>
								<td>1</td>
								<td>Kilgore</td>
								<td>Trout</td>
								<td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
							</tr>
              <tr>
								<td>1</td>
								<td>Kilgore</td>
								<td>Trout</td>
								<td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
                <td>kilgore</td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
export default {
    name: "Create",
    data(){
        return{

        }
    },
    components: {
        
    },
    props: [""],
    methods: {
        
    }
}
</script>
<style>
	.row{
		    margin-top:40px;
		    padding: 0 10px;
		}
		.clickable{
		    cursor: pointer;   
		}

		.panel-heading div {
			margin-top: -18px;
			font-size: 15px;
		}
		.panel-heading div span{
			margin-left:5px;
		}
		.panel-body{
			display: none;
		}
    .panel-title{
      align-items: center;
    }
    .container{
      margin-left: 30%;
      margin-top: 5%;
      border: 10px solid #222;
      width: 40%;
      border-radius: 50px;
      background: white;
    }
</style>
