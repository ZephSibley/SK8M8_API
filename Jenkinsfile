node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/sk8m8-api")
    }

    stage('Test') {
        app.inside {
            sh 'dotnet test'
        }
    }

    stage('Push image') {
        docker.withRegistry('http://localhost:4000') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}