node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/sk8m8-api")
    }

    stage('Push') {
        localhost
        docker.withRegistry('http:/127.0.0.1:5000') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}