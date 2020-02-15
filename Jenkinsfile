node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8-api")
    }

    stage('Push') {
        docker.withRegistry('https://index.docker.io/v1/sk8m8/testing-repo', 'dockerhub') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}