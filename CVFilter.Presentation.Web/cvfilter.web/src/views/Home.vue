<template>
  <div id="app">
     <div>
      <Label>Kullanıcı Adınızı Giriniz</Label>
      <input
        type="text"
        aria-placeholder="Kullanıcı Adı Giriniz"
        placeholder="Kullanıcı Adı Giriniz"
        ref="userName"
      />
    </div>
    <div>
      <input
        type="text"
        placeholder="Eşleşecek karakterleri giriniz"
        ref="matches"
      />
    </div>
    <div>
      <input
        type="text"
        placeholder="Dosya uzantısını kopyalayınız"
        ref="path"
      />
    </div> 
    <button type="button" @click="SendData()">Send Data</button>
  </div>
</template>
<script>
import * as Vue from 'vue'
export default {
  name: "Home",
  components: {},
  props: [""],
  methods: {
    GetFilePath(){
      this.path = this.$refs.path.files.file[0];
    },
    async SendData(){
      const request = {
        Path: this.$refs.path.value,
        User: this.$refs.userName.value,
        Matches: this.$refs.matches.value
      }
      const requestOptions = {
        method: "POST",
        mode: "cors",
        headers: { "Content-Type": "application/json", },
        body: JSON.stringify(request)
      };
    await fetch('http://localhost:5000/cv/',requestOptions)
    .then(response => console.log(response.json()))
    .catch((err) => console.log(err))
    }
  },
};
</script>
<style lang="scss" scoped>
#app {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  div {
    display: inline;
    input {
      margin: 0 15% 0 0;
      border-radius: 10px;
      height: 30px;
      border: none;
      border: solid 1px #ccc;
      text-align: center;
    }
  }
}

</style>
