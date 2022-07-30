<template>
<form class="form-config">
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputEmail4">Email</label>
      <input type="email" class="form-control" id="inputEmail4" placeholder="Email">
    </div>
    <div class="form-group col-md-6">
      <label for="inputPassword4">Password</label>
      <input type="password" class="form-control" id="inputPassword4" placeholder="Password">
    </div>
  </div>
  <div class="form-group">
    <label for="inputAddress">Address</label>
    <input type="text" class="form-control" id="inputAddress" placeholder="1234 Main St">
  </div>
  <div class="form-group">
    <label for="inputAddress2">Address 2</label>
    <input type="text" class="form-control" id="inputAddress2" placeholder="Apartment, studio, or floor">
  </div>
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCity">City</label>
      <input type="text" class="form-control" id="inputCity">
    </div>
    <div class="form-group col-md-4">
      <label for="inputState">State</label>
      <select id="inputState" class="form-control">
        <option selected>Choose...</option>
        <option>...</option>
      </select>
    </div>
    <div class="form-group col-md-2">
      <label for="inputZip">Zip</label>
      <input type="text" class="form-control" id="inputZip">
    </div>
  </div>
  <div class="form-group">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" id="gridCheck">
      <label class="form-check-label" for="gridCheck">
        Check me out
      </label>
    </div>
  </div>
  <button type="submit" class="btn btn-primary">Sign in</button>
</form>
</template>
<script>
export default {
    name: "Edit",
    data(){
        return{

        }
    },
    components: {
        
    },
    props: [""],
    methods: {
    async GetApplicant(id){
      const requestOptions = {
        method: "GET",
        mode: "cors",
        headers: { "Content-Type": "application/json",}
      };
    await fetch('http://localhost:7000/cv/getbyid?Id='+id,requestOptions)
    .then(response => {
		if(response.status != 200)
		{
			alert("There is an error! Check logs!");
		}
	})
    .catch((err) => alert(err))
    }
    }
}
</script>
<style>
.form-config {
    align-items: center;
    justify-content: center;
    width: 50%;
    margin-left:25%;
    margin-top:10%;
    border: 10px solid rgb(83, 183, 161);
    border-radius: 50px;
    background: rgb(142, 152, 226);
}
</style>