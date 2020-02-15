node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/sk8m8-api")
    }

    stage('Push') {
        docker.withRegistry('http://registry.me:5000') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}